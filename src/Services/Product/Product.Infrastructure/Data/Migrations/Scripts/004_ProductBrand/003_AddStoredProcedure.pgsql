-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Query: Get product brands by product_id
CREATE OR REPLACE FUNCTION sp_get_product_brands_by_product_id(
  productId UUID
)
RETURNS SETOF product_brand AS $$
BEGIN
  RETURN QUERY
  SELECT  *
    FROM  product_brand
   WHERE  product_id = productId
     AND  valid_flg = TRUE;
END;
$$ LANGUAGE plpgsql;

-- Query: Get product brand by product_id, brand_id, and brand_no
CREATE OR REPLACE FUNCTION sp_get_product_brand_by_id(
  productId UUID,
  brandId VARCHAR,
  brandNo SMALLINT
)
RETURNS SETOF product_brand AS $$
BEGIN
  RETURN QUERY
  SELECT  *
    FROM  product_brand
   WHERE  product_id = productId
     AND  brand_id = brandId
     AND  brand_no = brandNo
     AND  valid_flg = TRUE;
END;
$$ LANGUAGE plpgsql;

-- Command: Insert product brand
CREATE OR REPLACE FUNCTION sp_insert_product_brand(
  productId UUID,
  brandId VARCHAR,
  createdBy VARCHAR,
  lastModifiedBy VARCHAR,
  brandNo SMALLINT DEFAULT 0,
  isPrimary BOOLEAN DEFAULT FALSE,
  validFlg BOOLEAN DEFAULT TRUE
)
RETURNS VOID AS $$
BEGIN
  INSERT INTO product_brand (
    product_id,
    brand_id,
    brand_no,
    is_primary,
    valid_flg,
    created_at,
    created_by,
    last_modified,
    last_modified_by
  )
  VALUES (
    productId,
    brandId,
    brandNo,
    isPrimary,
    validFlg,
    CURRENT_TIMESTAMP,
    createdBy,
    CURRENT_TIMESTAMP,
    lastModifiedBy
  );
END;
$$ LANGUAGE plpgsql;

-- Command: Update product brand
CREATE OR REPLACE FUNCTION sp_update_product_brand(
  productId UUID,
  brandId VARCHAR,
  lastModifiedBy VARCHAR,
  brandNo SMALLINT DEFAULT 0,
  isPrimary BOOLEAN DEFAULT FALSE,
  validFlg BOOLEAN DEFAULT TRUE
)
RETURNS VOID AS $$
BEGIN
  UPDATE  product_brand
     SET  is_primary = isPrimary,
          valid_flg = validFlg,
          last_modified = CURRENT_TIMESTAMP,
          last_modified_by = lastModifiedBy
   WHERE  product_id = productId
     AND  brand_id = brandId
     AND  brand_no = brandNo;
END;
$$ LANGUAGE plpgsql;

-- Command: Delete product brand
CREATE OR REPLACE FUNCTION sp_delete_product_brand(
  productId UUID,
  brandId VARCHAR,
  brandNo SMALLINT DEFAULT 0
)
RETURNS VOID AS $$
BEGIN
  DELETE FROM product_brand
   WHERE  product_id = productId
     AND  brand_id = brandId
     AND  brand_no = brandNo;
END;
$$ LANGUAGE plpgsql;
