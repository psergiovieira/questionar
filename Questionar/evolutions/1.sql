CREATE TABLE security.user_account
(
   id serial NOT NULL PRIMARY KEY,
   password text NOT NULL, 
   name text NOT NULL, 
   created time without time zone NOT NULL, 
   email text NOT NULL   
) 
WITH (
  OIDS = FALSE
)
;
