ALTER TABLE public.answer
  DROP COLUMN created;
ALTER TABLE public.answer
  ADD COLUMN created timestamp without time zone NOT NULL;
  
  
ALTER TABLE public.course
  DROP COLUMN created;
ALTER TABLE public.course
  ADD COLUMN created timestamp with time zone NOT NULL;
  
  
ALTER TABLE public.subscription
  DROP COLUMN date_entered;
ALTER TABLE public.subscription
  ADD COLUMN date_entered timestamp with time zone NOT NULL;
