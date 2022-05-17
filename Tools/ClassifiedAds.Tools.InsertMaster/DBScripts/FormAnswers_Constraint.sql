SET NUMERIC_ROUNDABORT OFF
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
DECLARE @pv binary(16)

ALTER TABLE [Survey].[FormAnswers]
    ADD CONSTRAINT [FK_FormAnswers_Answer] FOREIGN KEY ([AnswerId]) REFERENCES [Survey].[Answers] ([Id])
ALTER TABLE [Survey].[FormAnswers]
    ADD CONSTRAINT [FK_FormAnswers_Form] FOREIGN KEY ([FormId]) REFERENCES [Survey].[Forms] ([Id])
ALTER TABLE [Survey].[FormAnswers]
    ADD CONSTRAINT [FK_FormAnswers_HouseholdMember] FOREIGN KEY ([HouseHoldMemberId]) REFERENCES [Enumeration].[HouseHoldMembers] ([Id])
ALTER TABLE [Survey].[FormAnswers]
    ADD CONSTRAINT [FK_FormAnswers_Household] FOREIGN KEY ([HouseholdId]) REFERENCES [Enumeration].[Households] ([Id])
ALTER TABLE [Survey].[FormAnswers]
    ADD CONSTRAINT [FK_FormAnswers_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Survey].[Questions] ([Id])
ALTER TABLE [Survey].[FormAnswers]
    ADD CONSTRAINT [FK_FormAnswers_RootQuestion] FOREIGN KEY ([RootQuestionId]) REFERENCES [Survey].[Questions] ([Id])
