using System;
using System.Xml.Serialization;

namespace SimpleBDD.Results
{
	/// <summary>
	/// Step result containing step name, its number in a list and its status.
	/// </summary>
	[Serializable]
	public class StepResult
	{
		/// <summary>
		/// Step name.
		/// </summary>
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		/// <summary>
		/// Step status.
		/// </summary>
		[XmlAttribute(AttributeName = "Status")]
		public ResultStatus Status { get; set; }

		/// <summary>
		/// Step number.
		/// </summary>
		[XmlAttribute(AttributeName = "StepNumber")]
		public int StepNumber { get; set; }
		/// <summary>
		/// Total number of steps.
		/// </summary>
		[XmlAttribute(AttributeName = "TotalStepsCount")]
		public int TotalStepsCount { get; set; }

		/// <summary>
		/// Initializes step result with all data.
		/// </summary>
		/// <param name="stepNumber">Step number.</param>
		/// <param name="totalStepsCount">Total number of steps.</param>
		/// <param name="stepName">Step name.</param>
		/// <param name="stepStatus">Step status.</param>
		public StepResult(int stepNumber, int totalStepsCount, string stepName, ResultStatus stepStatus)
		{
			StepNumber = stepNumber;
			TotalStepsCount = totalStepsCount;
			Name = stepName;
			Status = stepStatus;
		}

		/// <summary>
		/// Default constructor;
		/// </summary>
		public StepResult()
		{

		}

		/// <summary>
		/// Compares two instances of step results.
		/// </summary>
		/// <param name="other">Other step.</param>
		/// <returns>True if equal, otherwise false.</returns>
		public bool Equals(StepResult other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.StepNumber == StepNumber && other.TotalStepsCount == TotalStepsCount && Equals(other.Name, Name) && Equals(other.Status, Status);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
		/// </returns>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(StepResult)) return false;
			return Equals((StepResult)obj);
		}

		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			unchecked
			{
				int result = StepNumber;
				result = (result * 397) ^ TotalStepsCount;
				result = (result * 397) ^ (Name != null ? Name.GetHashCode() : 0);
				result = (result * 397) ^ Status.GetHashCode();
				return result;
			}
		}

		public override string ToString()
		{
			return string.Format("{0}/{1} {2}: {3}", StepNumber, TotalStepsCount, Name, Status);
		}
	}
}