-- DROP SEQUENCE question_id_seq;

CREATE SEQUENCE question_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE question_id_seq
  OWNER TO postgres;





-- Table: public.question

-- DROP TABLE public.question;

CREATE TABLE public.question
(
  id integer NOT NULL DEFAULT nextval('question_id_seq'::regclass),
  id_course integer NOT NULL,
  description text NOT NULL,
  CONSTRAINT id_question PRIMARY KEY (id),
  CONSTRAINT course FOREIGN KEY (id_course)
      REFERENCES public.course (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.question
  OWNER TO postgres;