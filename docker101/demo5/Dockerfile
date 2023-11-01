# 階段 1：構建應用
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# 複製 csproj 檔案並還原任何依賴項（如果有的話）
COPY *.csproj ./
RUN dotnet restore

# 複製應用程式原始碼並構建
COPY . ./
RUN dotnet publish -c Release -o out

# 階段 2：執行時
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# 設定環境變數（如果需要）
ENV ASPNETCORE_URLS=http://+:5208

# 啟動應用程式
ENTRYPOINT ["dotnet", "YourApp.dll"]
