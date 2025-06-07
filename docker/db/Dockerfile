FROM postgres:16

# Criação de usuário não root
ENV POSTGRES_USER=embrace_user
ENV POSTGRES_PASSWORD=embrace_pass
ENV POSTGRES_DB=embrace_db

USER postgres
WORKDIR /var/lib/postgresql/data
EXPOSE 5432
