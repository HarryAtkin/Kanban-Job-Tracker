CREATE Table contributors (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    board_id bigint NOT NULL REFERENCES board(id) ON DELETE CASCADE,
    account_id bigint NOT NULL REFERENCES account(id) ON DELETE CASCADE,
    permission_type text NOT NULL
    );