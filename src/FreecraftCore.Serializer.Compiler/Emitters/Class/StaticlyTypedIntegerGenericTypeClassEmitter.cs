﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FreecraftCore.Serializer
{
	public sealed class StaticlyTypedIntegerGenericTypeClassEmitter<TValueType>
		where TValueType : unmanaged
	{
		public TValueType LiteralValue { get; }

		public StaticlyTypedIntegerGenericTypeClassEmitter(TValueType literalValue)
		{
			LiteralValue = literalValue;
		}

		public ClassDeclarationSyntax Create()
		{
			return ClassDeclaration
				(
					Identifier
					(
						TriviaList(),
						new StaticlyTypedNumericNameBuilder<TValueType>(LiteralValue).BuildName(), 
						TriviaList
						(
							Space
						)
					)
				)
				.WithModifiers
				(
					TokenList
					(
						new[]
						{
							Token
							(
								TriviaList(),
								SyntaxKind.PrivateKeyword,
								TriviaList
								(
									Space
								)
							),
							Token
							(
								TriviaList(),
								SyntaxKind.SealedKeyword,
								TriviaList
								(
									Space
								)
							)
						}
					)
				)
				.WithKeyword
				(
					Token
					(
						TriviaList(),
						SyntaxKind.ClassKeyword,
						TriviaList
						(
							Space
						)
					)
				)
				.WithBaseList
				(
					BaseList
						(
							SingletonSeparatedList<BaseTypeSyntax>
							(
								SimpleBaseType
								(
									GenericName
										(
											Identifier("StaticTypedNumeric")
										)
										.WithTypeArgumentList
										(
											TypeArgumentList
												(
													SingletonSeparatedList<TypeSyntax>
													(
														IdentifierName(typeof(TValueType).Name)
													)
												)
												.WithGreaterThanToken
												(
													Token
													(
														TriviaList(),
														SyntaxKind.GreaterThanToken,
														TriviaList
														(
															Space
														)
													)
												)
										)
								)
							)
						)
						.WithColonToken
						(
							Token
							(
								TriviaList(),
								SyntaxKind.ColonToken,
								TriviaList
								(
									Space
								)
							)
						)
				)
				.WithOpenBraceToken
				(
					Token
					(
						TriviaList(),
						SyntaxKind.OpenBraceToken,
						TriviaList
						(
							Space
						)
					)
				)
				.WithMembers
				(
					SingletonList<MemberDeclarationSyntax>
					(
						PropertyDeclaration
							(
								IdentifierName
								(
									Identifier
									(
										TriviaList(),
										typeof(TValueType).Name,
										TriviaList
										(
											Space
										)
									)
								),
								Identifier
								(
									TriviaList(),
									"Value",
									TriviaList
									(
										Space
									)
								)
							)
							.WithModifiers
							(
								TokenList
								(
									new[]
									{
										Token
										(
											TriviaList(),
											SyntaxKind.PublicKeyword,
											TriviaList
											(
												Space
											)
										),
										Token
										(
											TriviaList(),
											SyntaxKind.SealedKeyword,
											TriviaList
											(
												Space
											)
										),
										Token
										(
											TriviaList(),
											SyntaxKind.OverrideKeyword,
											TriviaList
											(
												Space
											)
										)
									}
								)
							)
							.WithExpressionBody
							(
								ArrowExpressionClause
									(
										IdentifierName(LiteralValue.ToString())
									)
									.WithArrowToken
									(
										Token
										(
											TriviaList(),
											SyntaxKind.EqualsGreaterThanToken,
											TriviaList
											(
												Space
											)
										)
									)
							)
							.WithSemicolonToken
							(
								Token
								(
									TriviaList(),
									SyntaxKind.SemicolonToken,
									TriviaList
									(
										Space
									)
								)
							)
					)
				)
				.WithCloseBraceToken
				(
					Token
					(
						TriviaList
						(
						),
						SyntaxKind.CloseBraceToken,
						TriviaList
						(
							CarriageReturnLineFeed
						)
					)
				);
		}
	}
}
