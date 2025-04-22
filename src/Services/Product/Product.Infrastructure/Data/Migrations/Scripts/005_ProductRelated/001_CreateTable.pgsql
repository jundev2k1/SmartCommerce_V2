-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE TABLE IF NOT EXISTS product_related (
  product_id UUID NOT NULL REFERENCES product(product_id) ON DELETE CASCADE,
  related_product_id UUID NOT NULL REFERENCES product(product_id) ON DELETE CASCADE,
  related_variant_id UUID REFERENCES product_variant(variant_id) ON DELETE CASCADE,
  product_no INT NOT NULL DEFAULT 0,
  valid_flg BOOLEAN DEFAULT TRUE,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  created_by VARCHAR(60) DEFAULT 'system',
  last_modified TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  last_modified_by VARCHAR(60) DEFAULT 'system',

  PRIMARY KEY (product_id, related_product_id),
  CONSTRAINT uq_product_product_no UNIQUE (product_id, product_no)
);