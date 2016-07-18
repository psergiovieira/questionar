-- Table: public.user_question

-- DROP TABLE public.user_question;

CREATE TABLE public.user_question
(
  id integer NOT NULL DEFAULT nextval('user_question_id_seq'::regclass),
  id_question integer NOT NULL,
  id_user integer NOT NULL,
  created date NOT NULL,
  CONSTRAINT user_question_pkey PRIMARY KEY (id),
  CONSTRAINT user_question_id_question_fkey FOREIGN KEY (id_question)
      REFERENCES public.question (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT user_question_id_user_fkey FOREIGN KEY (id_user)
      REFERENCES security.user_account (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.user_question
  OWNER TO postgres;
