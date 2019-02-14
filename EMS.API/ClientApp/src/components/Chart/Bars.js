
import React, { Component } from 'react'
import { scaleLinear } from 'd3-scale'
import { interpolateCubehelix } from 'd3-interpolate'

export default class Bars extends Component {
  constructor(props) {
    super(props)

    this.colorScale = scaleLinear()
      .domain([0, this.props.maxValue])
      .range(["#f79494","#ceefa7"])
      .interpolate(interpolateCubehelix)

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
    console.log({data, props:this.props});
    const bars = (
      data.map(datum =>
        <rect
          key={datum.userId}
          x={xScale(datum.grade)}
          y={yScale(datum.grade)}
          height={height - margins.bottom - scales.yScale(datum.grade)}
          width={xScale.bandwidth()}
          fill={this.getColor(datum)}
        />
      )
    )

    return (
      <g>{bars}</g>
    )
  }
}
