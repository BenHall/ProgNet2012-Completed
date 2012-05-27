@open 'http://www.google.com', ->
  @describe 'input(..)', ->
    @$('[name="q"]').input 'meaning of life'
    @$('input[type="submit"]').click ->
      console.log @$('#res').attr('innerText')
      throw 'exit'