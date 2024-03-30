import ollama

response = ollama.chat(model='llama2', messages=[
  {
    'role': 'user',
    'content': str(input('What do you want to know?\n')),
  },
])
print(response['message']['content'])