# Natural Sort

A natural sort tool for JavaScript, designed for use with underscore.js and CouchDB.

# Background

The excellent and well-tested [js-naturalsort](http://code.google.com/p/js-naturalsort/) has almost everything I want, but it doesn't work with underscore.js and CouchDB because it does a binary compare rather than generate sort keys. This takes one value and returns a sort key in the form of an array, rather than simply comparing two values. The results may be slightly different but it will hopefully work well enough to be useful.

# Status

The binary comparison from js-naturalsort has been added as `naturalsort.compare(value1, value2)`, along with the tests, which can be run with `npm test`.

The sort key function has been added as `naturalsort.key(value)`. It currently only handles converting a single positive integer string to a number.

This is run through the tests from js-naturalsort. 13 tests fail with `_.sortBy(arr, naturalsort.key)`. 17 tests fail when using what amounts to a plain sort().

# Credits

*naturalsort*:

* Ben Atkin

The authors and contributors of the original *js-naturalsort*:

* Jim Palmer
* Mike Grier (mgrier.com)
* Clint Priest
* Kyle Adams
* guillermo

# License

Licensed under the terms of the MIT License, available in LICENSE.md.