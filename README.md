# 로그라이크 프로젝트

## 📂 프로젝트 구조
- **/docs**: SDS, 기획서 등 모든 문서를 포함합니다.
- **/assets**: 이미지, 사운드 등 리소스 파일을 포함합니다.
- 이런 식으로 추가할 것임

---

## 🔀 Git Branch 전략
- **main**: Release branch 
    - **직접 수정 및 PR 절대 금지!!!**
- **develop**: Develop test branch
    - 개발된 기능을 병합하고 테스트하는 브랜치입니다.
    - 문서 작업 또한 이 브랜치로 병합됩니다.
- **feat/#{issue_number}/{feature_name}**: Normal working branch
    - 기능 개발 브랜치입니다. 일반적인 프로젝트 작업은 모두 이 브랜치에서 이루어집니다.
- **hotfix/#{issue_number}/{hotfix_name}**: Bug working branch
    - main 브랜치에 병합한 기능이 오류를 일으키는 경우, 빠르게 수정하는 브랜치입니다.
- **doc/#{issue_number}/{doc_name}**: Document branch
    - 문서 작업용 브랜치입니다.
- **refactor/#{issue_number}/{name}**: Refactoring branch
    - 리팩토링 전용 브랜치입니다. 코드 리팩토링, 프로젝트 구조 변경 등이 포함됩니다.

### 예시:

- 브랜치 이름 예시: `feat/18/playermove`
- **한 브랜치는 한 작업만!**
- 커밋 메시지 예시: `doc: Use Case 7~13 내용 추가`, `feat: 플레이어 이동 구현`
- Pull Request 제목은 **커밋 메시지와 동일하게**
- Pull Request 본문에는 issues number 포함할 것(#16 이런 식으로 샵 기호까지)

---

## 작업 간단 가이드

1. 자신의 fork 저장소와 원본 저장소 간 develop 브랜치의 Sync가 맞는지 확인
2. 작업 유형에 따른 브랜치 생성(Git Branch 전략 항목 참조)
    - 원본 저장소 Issues 탭에서 {issue_number} 확인
3. 원본 저장소 develop 브랜치로 Pull Request
