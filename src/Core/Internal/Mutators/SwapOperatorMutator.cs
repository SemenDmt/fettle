﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Fettle.Core.Internal.Mutators
{
    internal class ReplaceOperatorMutator : IMutator
    {
        private readonly string from;
        private readonly string to;

        public ReplaceOperatorMutator(string from, string to)
        {
            this.from = from;
            this.to = to;
        }

        public SyntaxNode Mutate(SyntaxNode node)
        {
            var newExpression = node.ToString().Replace(from, to);
            return SyntaxFactory.ParseExpression(newExpression)
                                .WithLeadingTrivia(node.GetLeadingTrivia())
                                .WithTrailingTrivia(node.GetTrailingTrivia());
        }
    }
}