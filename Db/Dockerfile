FROM mysql:5.7

#Creates tables and fills them with dummy data.
#TODO: Init tables, populate with data.
COPY init.sql /docker-entrypoint-initdb.d
COPY populate.sql /docker-entrypoint-initdb.d