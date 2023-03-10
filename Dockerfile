FROM gitlab.teamjet.ru:4567/teamjet/dockers/frontend-ci:12.7.0-curl as builder

ARG COMMIT_HASH

WORKDIR /usr/src/app
COPY package.json yarn.lock ./
RUN yarn install --frozen-lockfile

COPY . .
RUN yarn prod
RUN echo "{\"release\":\"$COMMIT_HASH\"}" > dist/release.json
RUN mv ./nginx.conf ./tjweb.conf

FROM nginx:1.14.0-alpine

COPY --from=builder /usr/src/app/dist /usr/share/nginx/html
RUN  rm /etc/nginx/conf.d/default.conf
COPY --from=builder /usr/src/app/*.conf /etc/nginx/conf.d/
