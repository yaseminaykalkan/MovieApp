# pull the official base image
FROM node
# set working direction
WORKDIR /usr/src/app
# add `/app/node_modules/.bin` to $PATH
ENV PATH "./node_modules/.bin:$PATH"
# install application dependencies
COPY ./mymovies/package.json ./
COPY ./mymovies/package-lock.json ./
RUN npm install
# add app
COPY ./mymovies/ .

# start app

RUN npm run build
#CMD ["npm", "start"]