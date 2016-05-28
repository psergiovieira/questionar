ALTER TABLE security.user_account
  ADD COLUMN active boolean NOT NULL DEFAULT true;
ALTER TABLE security.user_account
  ADD COLUMN is_teacher boolean NOT NULL DEFAULT false;