# angular 需要node 所以加入node
FROM node:14-alpine AS build

#指定/app目錄，準備將打包後檔案輸出至此，如不存在則會建立
WORKDIR /app

# 複製目錄檔案到image，將{資料夾名稱}/底下所有檔案 複製=> container中目錄 
COPY . .

# 安裝 Angular CLI
RUN npm install -g @angular/cli

# 針對container中執行npm i及npm build
ARG configuration=dev
RUN npm i && npm run build --${configuration}

# 啟動 Angular 開發伺服器，監視程式碼變化
CMD ["ng", "serve", "--host", "0.0.0.0", "--poll", "500"]

# 聲明要公開的埠（Angular 開發伺服器預設為 4200）
EXPOSE 4200