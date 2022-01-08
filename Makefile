meta.using := ms
meta.wrap := ms
include ../common_0.4.1.mk

v.files := Directory.Build.props
ms.solution := RemoteControl.ReactionMonitoring.sln

release.target := _release
.PHONY: _release
_release: MS_CONFIGURATION=Release
_release: bin.clean ms.build
	$(call release.rsync, $(BINDIR)/./*,)
