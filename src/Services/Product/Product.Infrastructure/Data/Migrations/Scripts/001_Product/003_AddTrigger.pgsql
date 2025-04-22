-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Create trigger to update search_vector on insert or update
CREATE OR REPLACE FUNCTION product_searchvector_update()
RETURNS trigger AS $$
BEGIN
  NEW.search_vector := to_tsvector(
    'simple',
    concat_ws(
      ' ',
      coalesce(NEW.name, ''),
      coalesce(NEW.short_description, ''),
      coalesce(NEW.description, '')
    )
  );
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS trg_update_product_searchvector ON product;

CREATE TRIGGER trg_update_product_searchvector
BEFORE INSERT OR UPDATE ON product
FOR EACH ROW
EXECUTE FUNCTION product_searchvector_update();