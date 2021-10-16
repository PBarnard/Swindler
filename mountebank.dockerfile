FROM alpine:3.14

EXPOSE 2525

CMD ["mb"]

ENV NODE_VERSION=14.17.6-r0 NPM_VERSION=7.17.0-r0

RUN apk update
RUN apk add --no-cache nodejs=${NODE_VERSION} npm=${NPM_VERSION}

ENV MOUNTEBANK_VERSION=2.4.0

RUN npm install -g mountebank@${MOUNTEBANK_VERSION} --production
RUN npm cache clean --force 2>/dev/null
RUN rm -rf /tmp/npm*