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