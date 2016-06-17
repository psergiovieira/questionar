CREATE TABLE public.subscriptions
(
   id serial, 
   id_course integer, 
   id_student integer, 
   date_entered time without time zone, 
   FOREIGN KEY (id_student) REFERENCES security.user_account (id) ON UPDATE NO ACTION ON DELETE NO ACTION, 
   FOREIGN KEY (id_course) REFERENCES course (id) ON UPDATE NO ACTION ON DELETE NO ACTION, 
   CONSTRAINT id_subscription PRIMARY KEY (id)
) 
WITH (
  OIDS = FALSE
)
;
ALTER TABLE subscriptions
   ALTER COLUMN id_course SET NOT NULL;
ALTER TABLE subscriptions
   ALTER COLUMN id_student SET NOT NULL;
ALTER TABLE subscriptions
   ALTER COLUMN date_entered SET NOT NULL;
   
ALTER TABLE subscriptions
  RENAME TO subscription;
