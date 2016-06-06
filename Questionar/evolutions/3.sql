CREATE TABLE public.course
(
   id serial NOT NULL, 
   name text, 
   description text, 
   CONSTRAINT id PRIMARY KEY (id)
) 
WITH (
  OIDS = FALSE
)
;
ALTER TABLE course
  ADD COLUMN created time without time zone;