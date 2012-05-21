this.open('https://github.com', function() {
		this.describe('Sign Up button', function() {
			this.assert.ok(this.$('.signup-button').length, 'expects button to be in the DOM');
			this.success();
			});
		});
