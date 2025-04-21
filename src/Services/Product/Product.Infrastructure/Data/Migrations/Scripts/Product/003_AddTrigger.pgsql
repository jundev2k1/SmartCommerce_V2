-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Create trigger to update SearchVector on insert or update
CREATE FUNCTION product_searchvector_update()
RETURNS trigger AS $$
  BEGIN
    NEW.SearchVector := to_tsvector('simple', 
      coalesce(NEW.Name, '') || ' ' || coalesce(NEW.Description, '') || ' ' || coalesce(NEW.ShortDescription, ''));
    RETURN NEW;
  END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_update_searchvector
BEFORE INSERT OR UPDATE ON Product
FOR EACH ROW EXECUTE FUNCTION product_searchvector_update();
