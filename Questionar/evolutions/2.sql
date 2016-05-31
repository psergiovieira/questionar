ALTER TABLE security.user_account
  ADD COLUMN active boolean NOT NULL DEFAULT true;
ALTER TABLE security.user_account
  ADD COLUMN is_teacher boolean NOT NULL DEFAULT false;
  
  ALTER TABLE security.user_account
   ALTER COLUMN active DROP DEFAULT;
ALTER TABLE security.user_account
   ALTER COLUMN is_teacher DROP DEFAULT;