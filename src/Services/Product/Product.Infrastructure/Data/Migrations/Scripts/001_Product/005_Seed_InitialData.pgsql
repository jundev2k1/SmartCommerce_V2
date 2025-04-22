-- Copyright (c) 2025 - Jun Dev. All rights reserved

DO $$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM product WHERE product_id = '11111111-1111-1111-1111-111111111111'::uuid
  ) THEN
    INSERT INTO product (
      product_id, sku, name, price, special_price, cost_price,
      rating, total_previews, short_description, description,
      slug, display_start, created_at, created_by,
      last_modified, last_modified_by
    )
    VALUES (
      '11111111-1111-1111-1111-111111111111'::uuid, -- product_id
      'SKU001',              -- sku
      'Product 1',           -- name
      100.00,                -- price
      90.00,                 -- special_price
      80.00,                 -- cost_price
      4.5,                   -- rating
      10,                    -- total_previews
      'Short description',   -- short_description
      'Full product description here', -- description
      'product-1',           -- slug
      CURRENT_TIMESTAMP,     -- display_start
      CURRENT_TIMESTAMP,     -- created_at
      'system',              -- created_by
      CURRENT_TIMESTAMP,     -- last_modified
      'system'               -- last_modified_by
    );
  END IF;
END $$;