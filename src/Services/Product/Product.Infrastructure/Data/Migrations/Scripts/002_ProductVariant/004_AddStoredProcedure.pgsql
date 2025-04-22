-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Query: Get all variants by productId
CREATE OR REPLACE FUNCTION sp_get_variants_by_product_id(
  productId UUID
)
RETURNS SETOF product_variant AS $$
BEGIN
  RETURN QUERY
  SELECT  *
    FROM  product_variant
   WHERE  product_id = productId
     AND  del_flg = FALSE;
END;
$$ LANGUAGE plpgsql;

-- Query: Get a single variant by variantId
CREATE OR REPLACE FUNCTION sp_get_variant_by_id(
  variantId UUID
)
RETURNS SETOF product_variant AS $$
BEGIN
  RETURN QUERY
  SELECT  *
    FROM  product_variant
   WHERE  variant_id = variantId AND del_flg = FALSE;
END;
$$ LANGUAGE plpgsql;

-- Command: Insert a new product variant
CREATE OR REPLACE FUNCTION sp_insert_variant(
  productId UUID,
  sku VARCHAR,
  name1 VARCHAR,
  name2 VARCHAR,
  name3 VARCHAR,
  price DECIMAL,
  specialPrice DECIMAL,
  costPrice DECIMAL,
  color VARCHAR,
  weight DECIMAL,
  size1 DECIMAL,
  size2 DECIMAL,
  size3 DECIMAL,
  displayStart TIMESTAMP,
  displayEnd TIMESTAMP,
  priority INT,
  barcode TEXT,
  slug VARCHAR,
  isDefault BOOLEAN,
  createdBy VARCHAR
)
RETURNS UUID AS $$
BEGIN
  INSERT INTO product_variant (
    variant_id,
    product_id,
    sku,
    name1,
    name2,
    name3,
    price,
    special_price,
    cost_price,
    color,
    weight,
    size1,
    size2,
    size3,
    display_start,
    display_end,
    priority,
    barcode,
    slug,
    is_default,
    created_by,
    last_modified_by
  ) VALUES (
    gen_random_uuid(),
    productId,
    sku,
    name1,
    name2,
    name3,
    price,
    specialPrice,
    costPrice,
    color,
    weight,
    size1,
    size2,
    size3,
    displayStart,
    displayEnd,
    priority,
    barcode,
    slug,
    isDefault,
    createdBy,
    createdBy
  );

  RETURN variantId;
END;
$$ LANGUAGE plpgsql;

-- Command: Update an existing product variant
CREATE OR REPLACE FUNCTION sp_update_variant(
  variantId UUID,
  sku VARCHAR,
  name1 VARCHAR,
  name2 VARCHAR,
  name3 VARCHAR,
  price DECIMAL,
  specialPrice DECIMAL,
  costPrice DECIMAL,
  color VARCHAR,
  weight DECIMAL,
  size1 DECIMAL,
  size2 DECIMAL,
  size3 DECIMAL,
  displayStart TIMESTAMP,
  displayEnd TIMESTAMP,
  priority INT,
  barcode TEXT,
  slug VARCHAR,
  validFlg BOOLEAN,
  isDefault BOOLEAN,
  lastModifiedBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  UPDATE  product_variant
     SET  sku = sku,
          name1 = name1,
          name2 = name2,
          name3 = name3,
          price = price,
          special_price = specialPrice,
          cost_price = costPrice,
          color = color,
          weight = weight,
          size1 = size1,
          size2 = size2,
          size3 = size3,
          display_start = displayStart,
          display_end = displayEnd,
          priority = priority,
          barcode = barcode,
          slug = slug,
          valid_flg = validFlg,
          is_default = isDefault,
          last_modified = CURRENT_TIMESTAMP,
          last_modified_by = lastModifiedBy
   WHERE  variant_id = variantId AND del_flg = FALSE;
END;
$$ LANGUAGE plpgsql;

-- Command: Soft delete a variant
CREATE OR REPLACE FUNCTION sp_soft_delete_variant(
  variantId UUID,
  lastModifiedBy VARCHAR
)
RETURNS VOID AS $$
BEGIN
  UPDATE  product_variant
     SET  del_flg = TRUE,
          last_modified = CURRENT_TIMESTAMP,
          last_modified_by = lastModifiedBy
   WHERE  variant_id = variantId;
END;
$$ LANGUAGE plpgsql;