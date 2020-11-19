﻿using System;
using System.Collections.Generic;
using System.Linq;
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

		public OverridenSerializationGenerator([NotNull] Type actualType, [NotNull] MemberInfo member, SerializationMode mode, [NotNull] Type serializerType)
			: base(actualType, member, mode)
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
							IdentifierName(Mode.ToString())))
					.WithArgumentList(
						ArgumentList(
							SeparatedList<ArgumentSyntax>(Mode == SerializationMode.Read ? ComputeReadMethodArgs() : ComputeWriteMethodArgs()))));
		}

		private SyntaxNodeOrToken[] ComputeReadMethodArgs()
		{
			return new SyntaxNodeOrToken[]{
				Argument(
					IdentifierName(CompilerConstants.BUFFER_NAME)),
				Token(
					TriviaList(),
					SyntaxKind.CommaToken,
					TriviaList(
						Space)),
				Argument(
						IdentifierName(CompilerConstants.OFFSET_NAME))
					.WithRefKindKeyword(
						Token(
							TriviaList(),
							SyntaxKind.RefKeyword,
							TriviaList(
								Space)))};
		}

		private SyntaxNodeOrToken[] ComputeWriteMethodArgs()
		{
			return new SyntaxNodeOrToken[]
				{
					Argument(
						IdentifierName($"{CompilerConstants.SERIALZIABLE_OBJECT_REFERENCE_NAME}.{Member.Name}")),
					Token(
						TriviaList(),
						SyntaxKind.CommaToken,
						TriviaList(
							Space))
				}
				.Concat(ComputeReadMethodArgs())
				.ToArray();
		}
	}
}