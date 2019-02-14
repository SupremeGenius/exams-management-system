
import React, { Component } from 'react'
import { scaleLinear } from 'd3-scale'
import { interpolateCubehelixLong } from 'd3-interpolate'

export default class Bars extends Component {
  constructor(props) {
    super(props)

    this.colorScale = scaleLinear()
      .domain([0, this.props.maxValue])
      .range(["#f79494","#ceefa7"])
      .interpolate(interpolateCubehelixLong)

    this.getColor = (item) => {
      if (item.grade === this.props.currentStudentGrade) {
        return '#0075ff'
      } else {
        return this.colorScale(item.grade)
      }
    }
  }

  render() {
    const { scales, margins, data, svgDimensions } = this.props
    const { xScale, yScale } = scales
    const { height } = svgDimensions

    const bars = (
      data.map((datum) => {
        let yHeight;
        if (this.props.gaussGradesNo) {
          yHeight = yScale(this.props.gaussGradesNo[datum.grade])
        } else {
          yHeight = yScale(this.props.gradesNo[datum.grade])
        }
        return <rect
          key={datum.userId}
          x={xScale(datum.grade)}
          y={yHeight}
          height={height - margins.bottom - yHeight}
          width={xScale.bandwidth()}
          fill={this.getColor(datum)}
        />

      })
    )

    return (
      <g>{bars}</g>
    )
  }
}
