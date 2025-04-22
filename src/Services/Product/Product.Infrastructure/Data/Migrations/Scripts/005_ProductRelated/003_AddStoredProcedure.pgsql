-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Query: Get related products by product_id
CREATE OR REPLACE FUNCTION sp_get_product_related_by_product_id(
  productId UUID
)
RETURNS SETOF product_related AS $$
BEGIN
  RETURN QUERY
  SELECT  *
    FROM  product_related
   WHERE  product_id = productId;
END;
$$ LANGUAGE plpgsql;

-- Query: Get product related by product_id and related_product_id
CREATE OR REPLACE FUNCTION sp_get_product_related(
  productId UUID,
  relatedProductId UUID,
  relatedVariantId UUID
)
RETURNS SETOF product_related AS $$
BEGIN
  RETURN QUERY
  SELECT  *
    FROM  product_related
   WHERE  product_id = productId
     AND  related_product_id = relatedProductId
     AND  (
            related_variant_id IS NULL
            OR
            related_variant_id = relatedVariantId
          );
END;
$$ LANGUAGE plpgsql;

-- Command: Insert product related
CREATE OR REPLACE FUNCTION sp_insert_product_related(
  productId UUID,
  relatedProductId UUID,
  relatedVariantId UUID,
  productNo INT,
  createdBy VARCHAR,
  lastModifiedBy VARCHAR,
  validFlg BOOLEAN DEFAULT TRUE
)
RETURNS VOID AS $$
BEGIN
  INSERT INTO product_related (
    product_id,
    related_product_id,
    related_variant_id,
    product_no,
    valid_flg,
    created_at,
    created_by,
    last_modified,
    last_modified_by
  )
  VALUES (
    productId,
    relatedProductId,
    relatedVariantId,
    productNo,
    validFlg,
    CURRENT_TIMESTAMP,
    createdBy,
    CURRENT_TIMESTAMP,
    lastModifiedBy
  );
END;
$$ LANGUAGE plpgsql;

-- Command: Update product related
CREATE OR REPLACE FUNCTION sp_update_product_related(
  productId UUID,
  relatedProductId UUID,
  relatedVariantId UUID,
  productNo INT,
  validFlg BOOLEAN,
  lastModifiedBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  UPDATE  product_related
     SET  related_variant_id = relatedVariantId,
          product_no = productNo,
          valid_flg = validFlg,
          last_modified = CURRENT_TIMESTAMP,
          last_modified_by = lastModifiedBy
   WHERE  product_id = productId
     AND  related_product_id = relatedProductId;
END;
$$ LANGUAGE plpgsql;

-- Command: Delete product related
CREATE OR REPLACE FUNCTION sp_delete_product_related(
  productId UUID,
  relatedProductId UUID,
  relatedVariantId UUID
)
RETURNS VOID AS $$
BEGIN
  DELETE FROM product_related
   WHERE  product_id = productId
     AND  related_product_id = relatedProductId
     AND  related_variant_id = relatedVariantId;
END;
$$ LANGUAGE plpgsql;
