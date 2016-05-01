-- Database: questionar

-- DROP DATABASE questionar;

CREATE DATABASE questionar
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'Portuguese_Brazil.1252'
       LC_CTYPE = 'Portuguese_Brazil.1252'
       CONNECTION LIMIT = -1;
	   
-- Schema: security

-- DROP SCHEMA security;

CREATE SCHEMA security
  AUTHORIZATION postgres;

