-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Query: Get products
CREATE OR REPLACE FUNCTION sp_get_products(
  productIds UUID[]
)
RETURNS SETOF product AS $$
BEGIN
  RETURN QUERY
  SELECT  *
    FROM  product
   WHERE  del_flg = FALSE
     AND  product_id = ANY(productIds);
END;
$$ LANGUAGE plpgsql;

-- Query: Get product by ID
CREATE OR REPLACE FUNCTION sp_get_product_by_id(
  productId UUID
)
RETURNS SETOF product AS $$
BEGIN
  RETURN QUERY
  SELECT  *
    FROM  product
   WHERE  del_flg = FALSE
     AND  product_id = productId;
END;
$$ LANGUAGE plpgsql;

-- Command: Insert product
CREATE OR REPLACE FUNCTION sp_insert_product(
  name VARCHAR,
  price DECIMAL(18, 2),
  specialPrice DECIMAL(18, 2),
  costPrice DECIMAL(18, 2),
  rating DECIMAL(3, 2),
  totalPreviews INT,
  shortDescription TEXT,
  description TEXT,
  slug VARCHAR(255),
  createdBy VARCHAR,
  lastModifiedBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  INSERT INTO product (
    product_id,
    name,
    price,
    special_price,
    cost_price,
    rating,
    total_previews,
    del_flg,
    short_description,
    description,
    slug,
    created_at,
    created_by,
    last_modified,
    last_modified_by
  )
  VALUES (
    gen_random_uuid(),
    name,
    price,
    specialPrice,
    costPrice,
    rating,
    totalPreviews,
    FALSE,
    shortDescription,
    description,
    slug,
    CURRENT_TIMESTAMP,
    createdBy,
    CURRENT_TIMESTAMP,
    lastModifiedBy
  );
END;
$$ LANGUAGE plpgsql;

-- Command: Update product
CREATE OR REPLACE FUNCTION sp_update_product(
  productId UUID,
  name VARCHAR,
  price DECIMAL(18, 2),
  specialPrice DECIMAL(18, 2),
  costPrice DECIMAL(18, 2),
  rating DECIMAL(3, 2),
  totalPreviews INT,
  shortDescription TEXT,
  description TEXT,
  slug VARCHAR(255),
  lastModifiedBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  UPDATE  product
     SET  name = name,
          price = price,
          special_price = specialPrice,
          cost_price = costPrice,
          rating = rating,
          total_previews = totalPreviews,
          short_description = shortDescription,
          description = description,
          slug = slug,
          last_modified = CURRENT_TIMESTAMP,
          last_modified_by = lastModifiedBy
   WHERE  del_flg = FALSE
     AND  product_id = productId;
END;
$$ LANGUAGE plpgsql;

-- Command: Soft delete product
CREATE OR REPLACE FUNCTION sp_soft_delete_product(
  productId UUID,
  changedBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  UPDATE  product
     SET  del_flg = TRUE,
          last_modified = CURRENT_TIMESTAMP,
          last_modified_by = changedBy
   WHERE  product_id = productId;
END;
$$ LANGUAGE plpgsql;
