ALTER TABLE public.user_question
  ADD COLUMN reply boolean NOT NULL DEFAULT false;

ALTER TABLE public.user_question RENAME reply  TO answered;