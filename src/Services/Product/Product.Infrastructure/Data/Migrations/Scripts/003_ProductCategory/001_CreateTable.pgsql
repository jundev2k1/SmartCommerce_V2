-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE TABLE IF NOT EXISTS product_category (
  product_id UUID NOT NULL REFERENCES product(product_id) ON DELETE CASCADE,
  category_id VARCHAR(60) NOT NULL DEFAULT '',
  category_no INT NOT NULL DEFAULT 0,
  display_flg BOOLEAN NOT NULL DEFAULT TRUE,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  created_by VARCHAR(60) NOT NULL DEFAULT 'system',
  last_modified TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  last_modified_by VARCHAR(60) NOT NULL DEFAULT 'system',

  PRIMARY KEY (product_id, category_id),
  CONSTRAINT uq_product_category_no UNIQUE (product_id, category_no)
);