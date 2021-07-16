# Pokedex
Rest Api returning Pokemon information using pokeapi.co

# How to run
1) Build the image using:

docker build -t pokemon .

2) Run container:

docker run -d -p 8030:80 docker.io/library/pokemon

3) Open:

 http://localhost:8030/Pokemon/mewtwo