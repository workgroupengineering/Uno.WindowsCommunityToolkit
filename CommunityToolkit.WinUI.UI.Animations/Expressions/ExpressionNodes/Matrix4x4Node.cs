// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Numerics;

namespace CommunityToolkit.WinUI.UI.Animations.Expressions
{
    // Ignore warning: 'Matrix4x4Node' defines operator == or operator != but does not override Object.Equals(object o) && Object.GetHashCode()
#pragma warning disable CS0660, CS0661
    /// <summary>
    /// Class Matrix4x4Node. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="CommunityToolkit.WinUI.UI.Animations.Expressions.ExpressionNode" />
    public sealed partial class Matrix4x4Node : ExpressionNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4x4Node"/> class.
        /// </summary>
        internal Matrix4x4Node()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4x4Node"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal Matrix4x4Node(Matrix4x4 value)
        {
            _value = value;
            NodeType = ExpressionNodeType.ConstantValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4x4Node"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        internal Matrix4x4Node(string paramName)
        {
            ParamName = paramName;
            NodeType = ExpressionNodeType.ConstantParameter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix4x4Node"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        internal Matrix4x4Node(string paramName, Matrix4x4 value)
        {
            ParamName = paramName;
            _value = value;
            NodeType = ExpressionNodeType.ConstantParameter;

            SetMatrix4x4Parameter(paramName, value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Matrix4x4"/> to <see cref="Matrix4x4Node"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Matrix4x4Node(Matrix4x4 value)
        {
            return new Matrix4x4Node(value);
        }

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static Matrix4x4Node operator +(Matrix4x4Node left, Matrix4x4Node right)
        {
            return ExpressionFunctions.Function<Matrix4x4Node>(ExpressionNodeType.Add, left, right);
        }

        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static Matrix4x4Node operator -(Matrix4x4Node left, Matrix4x4Node right)
        {
            return ExpressionFunctions.Function<Matrix4x4Node>(ExpressionNodeType.Subtract, left, right);
        }

        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Matrix4x4Node operator -(Matrix4x4Node value)
        {
            return ExpressionFunctions.Function<Matrix4x4Node>(ExpressionNodeType.Negate, value);
        }

        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static Matrix4x4Node operator *(Matrix4x4Node left, ScalarNode right)
        {
            return ExpressionFunctions.Function<Matrix4x4Node>(ExpressionNodeType.Multiply, left, right);
        }

        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static Matrix4x4Node operator *(Matrix4x4Node left, Matrix4x4Node right)
        {
            return ExpressionFunctions.Function<Matrix4x4Node>(ExpressionNodeType.Multiply, left, right);
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static BooleanNode operator ==(Matrix4x4Node left, Matrix4x4Node right)
        {
            return ExpressionFunctions.Function<BooleanNode>(ExpressionNodeType.Equals, left, right);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static BooleanNode operator !=(Matrix4x4Node left, Matrix4x4Node right)
        {
            return ExpressionFunctions.Function<BooleanNode>(ExpressionNodeType.NotEquals, left, right);
        }

        /// <summary>
        /// Gets the channel11.
        /// </summary>
        /// <value>The channel11.</value>
        public ScalarNode Channel11
        {
            get { return GetSubchannels(Subchannel.Channel11); }
        }

        /// <summary>
        /// Gets the channel12.
        /// </summary>
        /// <value>The channel12.</value>
        public ScalarNode Channel12
        {
            get { return GetSubchannels(Subchannel.Channel12); }
        }

        /// <summary>
        /// Gets the channel13.
        /// </summary>
        /// <value>The channel13.</value>
        public ScalarNode Channel13
        {
            get { return GetSubchannels(Subchannel.Channel13); }
        }

        /// <summary>
        /// Gets the channel14.
        /// </summary>
        /// <value>The channel14.</value>
        public ScalarNode Channel14
        {
            get { return GetSubchannels(Subchannel.Channel14); }
        }

        /// <summary>
        /// Gets the channel21.
        /// </summary>
        /// <value>The channel21.</value>
        public ScalarNode Channel21
        {
            get { return GetSubchannels(Subchannel.Channel21); }
        }

        /// <summary>
        /// Gets the channel22.
        /// </summary>
        /// <value>The channel22.</value>
        public ScalarNode Channel22
        {
            get { return GetSubchannels(Subchannel.Channel22); }
        }

        /// <summary>
        /// Gets the channel23.
        /// </summary>
        /// <value>The channel23.</value>
        public ScalarNode Channel23
        {
            get { return GetSubchannels(Subchannel.Channel23); }
        }

        /// <summary>
        /// Gets the channel24.
        /// </summary>
        /// <value>The channel24.</value>
        public ScalarNode Channel24
        {
            get { return GetSubchannels(Subchannel.Channel24); }
        }

        /// <summary>
        /// Gets the channel31.
        /// </summary>
        /// <value>The channel31.</value>
        public ScalarNode Channel31
        {
            get { return GetSubchannels(Subchannel.Channel31); }
        }

        /// <summary>
        /// Gets the channel32.
        /// </summary>
        /// <value>The channel32.</value>
        public ScalarNode Channel32
        {
            get { return GetSubchannels(Subchannel.Channel32); }
        }

        /// <summary>
        /// Gets the channel33.
        /// </summary>
        /// <value>The channel33.</value>
        public ScalarNode Channel33
        {
            get { return GetSubchannels(Subchannel.Channel33); }
        }

        /// <summary>
        /// Gets the channel34.
        /// </summary>
        /// <value>The channel34.</value>
        public ScalarNode Channel34
        {
            get { return GetSubchannels(Subchannel.Channel34); }
        }

        /// <summary>
        /// Gets the channel41.
        /// </summary>
        /// <value>The channel41.</value>
        public ScalarNode Channel41
        {
            get { return GetSubchannels(Subchannel.Channel41); }
        }

        /// <summary>
        /// Gets the channel42.
        /// </summary>
        /// <value>The channel42.</value>
        public ScalarNode Channel42
        {
            get { return GetSubchannels(Subchannel.Channel42); }
        }

        /// <summary>
        /// Gets the channel43.
        /// </summary>
        /// <value>The channel43.</value>
        public ScalarNode Channel43
        {
            get { return GetSubchannels(Subchannel.Channel43); }
        }

        /// <summary>
        /// Gets the channel44.
        /// </summary>
        /// <value>The channel44.</value>
        public ScalarNode Channel44
        {
            get { return GetSubchannels(Subchannel.Channel44); }
        }

        /// <summary>
        /// Gets the channel11 channel22 channel33.
        /// </summary>
        /// <value>The channel11 channel22 channel33.</value>
        public Vector3Node Channel11Channel22Channel33
        {
            get { return GetSubchannels(Subchannel.Channel11, Subchannel.Channel22, Subchannel.Channel33); }
        }

        /// <summary>
        /// Gets the channel41 channel42 channel43.
        /// </summary>
        /// <value>The channel41 channel42 channel43.</value>
        public Vector3Node Channel41Channel42Channel43
        {
            get { return GetSubchannels(Subchannel.Channel41, Subchannel.Channel42, Subchannel.Channel43); }
        }

        /// <summary>
        /// Create a new type by re-arranging the Matrix subchannels.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>ScalarNode.</returns>
        public ScalarNode GetSubchannels(Subchannel s)
        {
            return SubchannelsInternal<ScalarNode>(s.ToString());
        }

        /// <summary>
        /// Create a new type by re-arranging the Matrix subchannels.
        /// </summary>
        /// <param name="s1">The first subchannel.</param>
        /// <param name="s2">The second subchannel.</param>
        /// <returns>Vector2Node</returns>
        public Vector2Node GetSubchannels(Subchannel s1, Subchannel s2)
        {
            return SubchannelsInternal<Vector2Node>(s1.ToString(), s2.ToString());
        }

        /// <summary>
        /// Create a new type by re-arranging the Matrix subchannels.
        /// </summary>
        /// <param name="s1">The first subchannel.</param>
        /// <param name="s2">The second subchannel.</param>
        /// <param name="s3">The third subchannel.</param>
        /// <returns>Vector3Node</returns>
        public Vector3Node GetSubchannels(Subchannel s1, Subchannel s2, Subchannel s3)
        {
            return SubchannelsInternal<Vector3Node>(s1.ToString(), s2.ToString(), s3.ToString());
        }

        /// <summary>
        /// Create a new type by re-arranging the Matrix subchannels.
        /// </summary>
        /// <param name="s1">The first subchannel.</param>
        /// <param name="s2">The second subchannel.</param>
        /// <param name="s3">The third subchannel.</param>
        /// <param name="s4">The fourth subchannel.</param>
        /// <returns>Vector4Node</returns>
        public Vector4Node GetSubchannels(Subchannel s1, Subchannel s2, Subchannel s3, Subchannel s4)
        {
            return SubchannelsInternal<Vector4Node>(s1.ToString(), s2.ToString(), s3.ToString(), s4.ToString());
        }

        /// <summary>
        /// Create a new type by re-arranging the Matrix subchannels.
        /// </summary>
        /// <param name="s1">The first subchannel.</param>
        /// <param name="s2">The second subchannel.</param>
        /// <param name="s3">The third subchannel.</param>
        /// <param name="s4">The fourth subchannel.</param>
        /// <param name="s5">The fifth subchannel.</param>
        /// <param name="s6">The sixth subchannel.</param>
        /// <returns>Matrix3x2Node</returns>
        public Matrix3x2Node GetSubchannels(Subchannel s1, Subchannel s2, Subchannel s3, Subchannel s4, Subchannel s5, Subchannel s6)
        {
            return SubchannelsInternal<Matrix3x2Node>(s1.ToString(), s2.ToString(), s3.ToString(), s4.ToString(), s5.ToString(), s6.ToString());
        }

        /// <summary>
        /// Create a new type by re-arranging the Matrix subchannels.
        /// </summary>
        /// <param name="s1">The first subchannel.</param>
        /// <param name="s2">The second subchannel.</param>
        /// <param name="s3">The third subchannel.</param>
        /// <param name="s4">The fourth subchannel.</param>
        /// <param name="s5">The fifth subchannel.</param>
        /// <param name="s6">The sixth subchannel.</param>
        /// <param name="s7">The seventh subchannel.</param>
        /// <param name="s8">The eighth subchannel.</param>
        /// <param name="s9">The ninth subchannel.</param>
        /// <param name="s10">The tenth subchannel.</param>
        /// <param name="s11">The eleventh subchannel.</param>
        /// <param name="s12">The twelfth subchannel.</param>
        /// <param name="s13">The thirteenth subchannel.</param>
        /// <param name="s14">The fourteenth subchannel.</param>
        /// <param name="s15">The fifteenth subchannel.</param>
        /// <param name="s16">The sixteenth subchannel.</param>
        /// <returns>Matrix4x4Node</returns>
#pragma warning disable SA1117 // Parameters must be on same line or separate lines
        public Matrix4x4Node GetSubchannels(Subchannel s1, Subchannel s2, Subchannel s3, Subchannel s4,
                                         Subchannel s5, Subchannel s6, Subchannel s7, Subchannel s8,
                                         Subchannel s9, Subchannel s10, Subchannel s11, Subchannel s12,
                                         Subchannel s13, Subchannel s14, Subchannel s15, Subchannel s16)
        {
            return SubchannelsInternal<Matrix4x4Node>(s1.ToString(), s2.ToString(), s3.ToString(), s4.ToString(),
                                                      s5.ToString(), s6.ToString(), s7.ToString(), s8.ToString(),
                                                      s9.ToString(), s10.ToString(), s11.ToString(), s12.ToString(),
                                                      s13.ToString(), s14.ToString(), s15.ToString(), s16.ToString());
        }
#pragma warning restore SA1117 // Parameters must be on same line or separate lines

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>System.String.</returns>
        protected internal override string GetValue()
        {
            return $"Matrix4x4({_value.M11.ToCompositionString()},{_value.M12.ToCompositionString()},{_value.M13.ToCompositionString()},{_value.M14.ToCompositionString()}," +
                             $"{_value.M21.ToCompositionString()},{_value.M22.ToCompositionString()},{_value.M23.ToCompositionString()},{_value.M24.ToCompositionString()}," +
                             $"{_value.M31.ToCompositionString()},{_value.M32.ToCompositionString()},{_value.M33.ToCompositionString()},{_value.M34.ToCompositionString()}," +
                             $"{_value.M41.ToCompositionString()},{_value.M42.ToCompositionString()},{_value.M43.ToCompositionString()},{_value.M44.ToCompositionString()})";
        }

        private Matrix4x4 _value;
    }
#pragma warning restore CS0660, CS0661
}