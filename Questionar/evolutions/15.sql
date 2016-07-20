ALTER TABLE public.question
  ADD COLUMN "order" integer NOT NULL;
ALTER TABLE public.question RENAME "order"  TO question_order;