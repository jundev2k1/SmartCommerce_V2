-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE TABLE IF NOT EXISTS product_images (
  product_id UUID NOT NULL REFERENCES product(product_id) ON DELETE CASCADE,
  variant_id UUID REFERENCES product_variant(variant_id) ON DELETE CASCADE,
  image_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  image_no INT NOT NULL DEFAULT 0,
  url TEXT NOT NULL,
  type VARCHAR(50) NOT NULL DEFAULT 'gallery',
  alt_text VARCHAR(255) DEFAULT '',
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  created_by VARCHAR(60) DEFAULT 'system',
  last_modified TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  last_modified_by VARCHAR(60) DEFAULT 'system',

  CONSTRAINT uq_product_images_image_no UNIQUE (product_id, variant_id, image_no)
);