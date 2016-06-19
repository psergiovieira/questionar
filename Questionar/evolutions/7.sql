-- Table: public.alternative

-- DROP TABLE public.alternative;

CREATE TABLE public.alternative
(
  id integer NOT NULL DEFAULT nextval('alternative_id_seq'::regclass),
  id_question integer NOT NULL,
  description text NOT NULL,
  is_correct boolean NOT NULL,
  CONSTRAINT id_alternative PRIMARY KEY (id),
  CONSTRAINT alternative_id_question_fkey FOREIGN KEY (id_question)
      REFERENCES public.question (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.alternative
  OWNER TO postgres;