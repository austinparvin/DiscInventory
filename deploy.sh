docker build -t sdg-disc-inventory-image .

docker tag sdg-disc-inventory-image registry.heroku.com/sdg-disc-inventory-api/web

docker push registry.heroku.com/sdg-disc-inventory-api/web

heroku container:release web -a sdg-disc-inventory-api