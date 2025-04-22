-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Create trigger to update SearchVector on insert or update
CREATE OR REPLACE FUNCTION product_variant_searchvector_update()
RETURNS trigger AS $$
  BEGIN
    NEW.search_vector := to_tsvector(
      'simple',
      concat_ws(
        ' ',
        coalesce(NEW.sku, ''),
        coalesce(NEW.name1, ''),
        coalesce(NEW.name2, ''),
        coalesce(NEW.name3, '')
      )
    );
    RETURN NEW;
  END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS trg_update_variant_searchvector ON product_variant;

CREATE TRIGGER trg_update_variant_searchvector
BEFORE INSERT OR UPDATE ON product_variant
FOR EACH ROW EXECUTE FUNCTION product_variant_searchvector_update();
