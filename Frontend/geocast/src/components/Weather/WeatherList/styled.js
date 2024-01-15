import styled from "@emotion/styled";
import { IconButton } from "@mui/material";

const ToggleIconStyle = styled(IconButton)`
  position: fixed;
  top: 16px;
  right: 16px;
`;

const FlexContainer = styled.div`
  display: flex;
  overflow-x: auto;
  padding: 16px;
  gap: 16px;
  height: 50vh;
  justify-content: center;
  &::-webkit-scrollbar {
    display: none;
  }


  @media (min-width: 1024px) {
    ::-webkit-scrollbar {
      display: block;
    }
  }

  @media (min-width: 768px) and (max-width: 1023px) {
    ::-webkit-scrollbar {
      display: block;
    }
    & > * {
      flex: 0 0
    }
  }

  @media (max-width: 767px) {
    & > * {
      flex: 0 0 100%;
    }
  }
`;

export {
    ToggleIconStyle,
    FlexContainer
}