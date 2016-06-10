DELETE FROM course;
ALTER TABLE course
  ADD COLUMN teacher_id integer NOT NULL;
ALTER TABLE course
  ADD FOREIGN KEY (teacher_id) REFERENCES security.user_account (id) ON UPDATE NO ACTION ON DELETE NO ACTION;
