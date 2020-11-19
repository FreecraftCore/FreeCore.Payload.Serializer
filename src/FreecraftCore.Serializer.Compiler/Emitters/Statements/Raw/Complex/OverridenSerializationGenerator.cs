﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FreecraftCore.Serializer
{
	//TODO: Support generics
	public sealed class OverridenSerializationGenerator : BaseSerializationStatementsBlockEmitter
	{
		public Type SerializerType { get; }

		public OverridenSerializationGenerator([NotNull] Type actualType, [NotNull] MemberInfo member, [NotNull] Type serializerType)
			: base(actualType, member)
		{
			SerializerType = serializerType ?? throw new ArgumentNullException(nameof(serializerType));
		}

		public override List<StatementSyntax> CreateStatements()
		{
			return new List<StatementSyntax>() { Create() };
		}

		public StatementSyntax Create()
		{
			return ExpressionStatement(
				InvocationExpression(
						MemberAccessExpression(
							SyntaxKind.SimpleMemberAccessExpression,
							MemberAccessExpression(
								SyntaxKind.SimpleMemberAccessExpression,
								IdentifierName(SerializerType.Name),
								IdentifierName("Instance")),
							IdentifierName("Write")))
					.WithArgumentList(
						ArgumentList(
							SeparatedList<ArgumentSyntax>(
								new SyntaxNodeOrToken[]{
									Argument(
										IdentifierName($"{CompilerConstants.SERIALZIABLE_OBJECT_REFERENCE_NAME}.{Member.Name}")),
									Token(
										TriviaList(),
										SyntaxKind.CommaToken,
										TriviaList(
											Space)),
									Argument(
										IdentifierName(CompilerConstants.OUTPUT_BUFFER_NAME)),
									Token(
										TriviaList(),
										SyntaxKind.CommaToken,
										TriviaList(
											Space)),
									Argument(
											IdentifierName(CompilerConstants.OUTPUT_OFFSET_NAME))
										.WithRefKindKeyword(
											Token(
												TriviaList(),
												SyntaxKind.RefKeyword,
												TriviaList(
													Space)))}))));
		}
	}
}
