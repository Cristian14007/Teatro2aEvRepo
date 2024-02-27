# front
npm install vite
npm run dev

# back
docker-compose up --build --force-recreate -d
heidi-->mysql, <YourStrong@Passw0rd> , 8002
dotnet ef database update  -p ./Data/BackEnd.Data.csproj -s ./API/BackEnd.API.csproj
f5 --> https/swagger