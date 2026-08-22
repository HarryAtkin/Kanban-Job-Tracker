CREATE Table lane (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    title text NOT NULL,
    lane_description text NOT NULL,
    board_id bigint NOT NULL REFERENCES board(id) ON DELETE CASCADE,
    lane_order int NOT NULL
    );