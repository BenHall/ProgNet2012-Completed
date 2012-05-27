@open 'http://www.google.com/', ->
  @describe 'Search returns ASP.net homepage', ->
    @$('[name="q"]').input 'ASP.net'
    console.log @$('#res').attr('innerText')
	@assert.contains("ASP.net", @$('#res').attr('innerText'))