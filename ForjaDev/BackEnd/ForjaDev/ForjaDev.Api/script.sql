CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE category (
    "Id" uuid NOT NULL,
    title VARCHAR NOT NULL,
    CONSTRAINT pk_category PRIMARY KEY ("Id")
);

CREATE TABLE "user" (
    "Id" uuid NOT NULL,
    password_hash VARCHAR NOT NULL,
    email VARCHAR NOT NULL,
    CONSTRAINT pk_user PRIMARY KEY ("Id")
);

CREATE TABLE member (
    "Id" uuid NOT NULL,
    created_at_utc TIMESTAMPTZ NOT NULL,
    "UserId" uuid NOT NULL,
    slug VARCHAR NOT NULL,
    name VARCHAR NOT NULL,
    bio TEXT NOT NULL,
    role_title VARCHAR,
    "Links" jsonb NOT NULL,
    CONSTRAINT pk_member PRIMARY KEY ("Id"),
    CONSTRAINT "FK_member_user_UserId" FOREIGN KEY ("UserId") REFERENCES "user" ("Id") ON DELETE CASCADE
);

CREATE TABLE following (
    "Id" uuid NOT NULL,
    "MemberToFollowId" uuid NOT NULL,
    "FollowingMemberId" uuid NOT NULL,
    CONSTRAINT pk_following PRIMARY KEY ("Id"),
    CONSTRAINT fk_following_follower_member FOREIGN KEY ("MemberToFollowId") REFERENCES member ("Id") ON DELETE CASCADE,
    CONSTRAINT fk_following_target_member FOREIGN KEY ("FollowingMemberId") REFERENCES member ("Id") ON DELETE CASCADE
);

CREATE TABLE post (
    "Id" uuid NOT NULL,
    tag VARCHAR NOT NULL,
    title VARCHAR NOT NULL,
    body Text NOT NULL,
    create_at_utc TIMESTAMPTZ NOT NULL,
    "CategoryId" uuid,
    "MemberId" uuid NOT NULL,
    likes_count INT NOT NULL DEFAULT 0,
    CONSTRAINT pk_post PRIMARY KEY ("Id"),
    CONSTRAINT fk_post_category FOREIGN KEY ("CategoryId") REFERENCES category ("Id"),
    CONSTRAINT fk_post_member FOREIGN KEY ("MemberId") REFERENCES member ("Id") ON DELETE CASCADE
);

CREATE TABLE comment (
    "Id" uuid NOT NULL,
    "MemberId" uuid NOT NULL,
    "PostId" uuid NOT NULL,
    message TEXT NOT NULL,
    create_at_utc TIMESTAMPTZ NOT NULL,
    "ParentCommentId" uuid,
    CONSTRAINT pk_comment PRIMARY KEY ("Id"),
    CONSTRAINT fk_comment_member FOREIGN KEY ("MemberId") REFERENCES member ("Id") ON DELETE CASCADE,
    CONSTRAINT fk_comment_parent_comment FOREIGN KEY ("ParentCommentId") REFERENCES comment ("Id"),
    CONSTRAINT fk_comment_post FOREIGN KEY ("PostId") REFERENCES post ("Id") ON DELETE CASCADE
);

CREATE TABLE "Like" (
    "Id" uuid NOT NULL,
    "PostId" uuid NOT NULL,
    "MemberId" uuid NOT NULL,
    CONSTRAINT pk_like PRIMARY KEY ("Id"),
    CONSTRAINT fk_like_member FOREIGN KEY ("MemberId") REFERENCES member ("Id"),
    CONSTRAINT fk_like_post FOREIGN KEY ("PostId") REFERENCES post ("Id")
);

CREATE INDEX "IX_comment_MemberId" ON comment ("MemberId");

CREATE INDEX "IX_comment_ParentCommentId" ON comment ("ParentCommentId");

CREATE INDEX "IX_comment_PostId" ON comment ("PostId");

CREATE INDEX "IX_following_FollowingMemberId" ON following ("FollowingMemberId");

CREATE UNIQUE INDEX ix_following_unique_relationship ON following ("MemberToFollowId", "FollowingMemberId");

CREATE INDEX "IX_Like_MemberId" ON "Like" ("MemberId");

CREATE INDEX "IX_Like_PostId" ON "Like" ("PostId");

CREATE UNIQUE INDEX "IX_member_UserId" ON member ("UserId");

CREATE INDEX "IX_post_CategoryId" ON post ("CategoryId");

CREATE INDEX "IX_post_MemberId" ON post ("MemberId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260205134724_InitialCreate', '10.0.2');

COMMIT;

