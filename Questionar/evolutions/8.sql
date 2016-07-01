-- Table: public.answer

-- DROP TABLE public.answer;

CREATE TABLE public.answer
(
  id serial NOT NULL,
  id_user integer NOT NULL,
  id_alternative integer NOT NULL,
  created time without time zone NOT NULL,
  CONSTRAINT id_answer PRIMARY KEY (id),
  CONSTRAINT alternative FOREIGN KEY (id_alternative)
      REFERENCES public.alternative (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT "user" FOREIGN KEY (id_user)
      REFERENCES security.user_account (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);