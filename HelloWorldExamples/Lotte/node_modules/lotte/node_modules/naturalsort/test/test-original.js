var vows   = require('vows');
var assert = require('assert');
var fs     = require('fs');
var _      = require('underscore');
var naturalsort = require('../naturalsort');

var suite = JSON.parse(fs.readFileSync(__dirname + '/original-suite.json', 'utf8'));

var makeTest = function(value) {
	return function() {
		var input = value.input, expected = value.expected;
		var result = input.slice(0);
		result.sort(naturalsort.compare);
		assert.deepEqual(result, expected);
	}
}

var makeContext = function(tests, makeTest) {
	var context = {};
	_.each(tests, function(value, key) {
		context[key] = makeTest(value);
	});
	return context;
}

var batch = {};

_.map(suite.batches[0], function(value, key) {
  batch[key] = makeContext(value, makeTest);
});

// 13 of these tests fail as of this commit
var keyBatch = {};

var makeKeyTest = function(value) {
	return function() {
		var input = value.input, expected = value.expected;
		var result = _.sortBy(input, function(value) {
			return naturalsort.key(value);
		});
		assert.deepEqual(result, expected);
	}
}

_.map(suite.batches[0], function(value, key) {
  keyBatch[key] = makeContext(value, makeKeyTest);
});

vows.describe(suite.name).addBatch({'compare()': batch}).addBatch({'key()': keyBatch}).export(module);