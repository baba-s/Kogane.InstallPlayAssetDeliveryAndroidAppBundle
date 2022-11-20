#!/bin/bash

AAB_PATH="$1"
APKS_PATH="$2"
JAVA_PATH="$3"
BUNDLETOOL="$4"

if [ -e "${APKS_PATH}" ]; then
    rm "${APKS_PATH}"
fi

# .aab から .apks を生成
"${JAVA_PATH}" -Xmx1G -jar \
    "${BUNDLETOOL}" \
    build-apks \
    --bundle="${AAB_PATH}" \
    --output="${APKS_PATH}" \
    --local-testing

# 生成した .apks を端末にインストール
"${JAVA_PATH}" -Xmx1G -jar \
    "${BUNDLETOOL}" \
    install-apks \
    --apks="${APKS_PATH}"